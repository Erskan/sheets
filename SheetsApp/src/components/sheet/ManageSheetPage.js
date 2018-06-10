import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as sheetActions from '../../actions/sheetActions';
import SheetForm from './SheetForm';

class ManageSheetPage extends React.Component {
    constructor(props, context) {
        super(props, context);

        this.state = {
            sheet: Object.assign({}, props.sheet),
            errors: {}
        };
    }

    render() {
        return (
            <div>
                <h1>Manage Sheet</h1>
                <SheetForm 
                    sheet={this.state.sheet}
                    errors={this.state.errors}
                    forces={this.props.forces}
                     />
            </div>
        );
    }
}

ManageSheetPage.propTypes = {
    sheet: PropTypes.object.isRequired,
    forces: PropTypes.array.isRequired
};

function mapStateToProps(state, ownProps) {
    let sheet = {
        id: 5,
        name: "Leader dude",
        movement: 6,
        weaponSkill: 2,
        ballisticSkill: 2,
        strength: 4,
        toughness: 4,
        wounds: 5,
        attacks: 3,
        leadership: 10,
        save: 3,
        invulnerableSave: 5
    };

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