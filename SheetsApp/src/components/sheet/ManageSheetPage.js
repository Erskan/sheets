import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as sheetActions from '../../actions/sheetActions';
import SheetForm from './SheetForm';
import toastr from 'toastr';

class ManageSheetPage extends React.Component {
    constructor(props, context) {
        super(props, context);

        this.state = {
            sheet: Object.assign({}, props.sheet),
            errors: {},
            saving: false,
            deleting: false
        };
        this.updateSheetState = this.updateSheetState.bind(this);
        this.saveSheet = this.saveSheet.bind(this);
        this.deleteSheet = this.deleteSheet.bind(this);
        this.redirect = this.redirect.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        if(nextProps.sheet && this.props.sheet.id != nextProps.sheet.id) {
            this.setState({sheet: Object.assign({}, nextProps.sheet)});
        }
        else {
            this.setState({sheet: Object.assign({}, createEmptySheet())});
        }
    }

    updateSheetState(event) {
        const field = event.target.name;
        let sheet = Object.assign({}, this.state.sheet);
        sheet[field] = event.target.value;
        return this.setState({sheet: sheet});
    }

    saveSheet(event) {
        event.preventDefault();
        this.setState({saving: true});
        this.props.actions.saveSheet(this.state.sheet)
        .then(() => this.redirect())
        .catch((error) => {
            toastr.error(error);
            this.setState({saving: false});
        });
    }

    deleteSheet(event) {
        event.preventDefault();
        this.setState({deleting: true});
        this.props.actions.deleteSheet(this.state.sheet)
        .then(() => this.redirect())
        .catch((error) => {
            toastr.error(error);
            this.setState({deleting: false});
        });
    }

    redirect() {
        this.setState({saving: false, deleting: false});
        toastr.success('Saved sheet!');
        this.context.router.push('/sheets');
    }

    render() {
        return (
            <div>
                <h1>Manage Sheet</h1>
                <SheetForm 
                    sheet={this.state.sheet}
                    errors={this.state.errors}
                    forces={this.props.forces}
                    onChange={this.updateSheetState}
                    onSave={this.saveSheet}
                    onDelete={this.deleteSheet}
                    saving={this.state.saving}
                     />
            </div>
        );
    }
}

ManageSheetPage.propTypes = {
    sheet: PropTypes.object.isRequired,
    forces: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
};

ManageSheetPage.contextTypes = {
    router: PropTypes.object
};

function createEmptySheet() {
    return {
        name: "",
        movement: 0,
        weaponSkill: 0,
        ballisticSkill: 0,
        strength: 0,
        toughness: 0,
        wounds: 0,
        attacks: 0,
        leadership: 0,
        save: 0,
        invulnerableSave: 0,
        forceId: 0
    };
}

function getSheetById(sheets, sheetId) {
    const sheet = sheets.filter(s => s.id == sheetId);
    if(sheet) {
        return sheet[0];
    }
    return null;
}

function mapStateToProps(state, ownProps) {
    const sheetId = ownProps.params.id;
    
    let sheet = createEmptySheet();

    if(sheetId && state.sheets.length > 0) {
        sheet = getSheetById(state.sheets, sheetId);
    }

    const forcesFormattedForSelect = state.forces.map((force) => {
        return {
            value: force.id,
            text: force.name
        };
    });
    return {
        sheet: sheet,
        forces: forcesFormattedForSelect
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(sheetActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ManageSheetPage);