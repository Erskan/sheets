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
            saving: false
        };
        this.updateSheetState = this.updateSheetState.bind(this);
        this.saveSheet = this.saveSheet.bind(this);
        this.redirect = this.redirect.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        if(this.props.sheet.id != nextProps.sheet.id) {
            this.setState({sheet: Object.assign({}, nextProps.sheet)});
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

    redirect() {
        this.setState({saving: false});
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

function getSheetById(sheets, sheetId) {
    const sheet = sheets.filter(s => s.id == sheetId);
    if(sheet) {
        return sheet[0];
    }
    return null;
}

function mapStateToProps(state, ownProps) {
    const sheetId = ownProps.params.id;
    
    let sheet = {
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