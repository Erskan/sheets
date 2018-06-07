import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as sheetActions from '../../actions/sheetActions';

class ManageSheetPage extends React.Component {
    constructor(props, context) {
        super(props, context);
    }

    render() {
        return (
            <h1>Manage Sheet</h1>
        );
    }
}

ManageSheetPage.propTypes = {

};

function mapStateToProps(state, ownProps) {
    return {
        state: state
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(sheetActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ManageSheetPage);