import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as sheetActions from '../../actions/sheetActions';

class SheetsPage extends React.Component{
    constructor(props, context) {
        super(props, context);
    }

    sheetsRow(sheet, index) {
        return <div key={index}>{sheet.name}</div>;
    }

    render() {
        return(
            <div>
                <h1>Sheets</h1>
                {this.props.sheets.map(this.sheetsRow)}
            </div>
        );
    }
}

SheetsPage.propTypes = {
    sheets: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
};

function mapStateToProps(state, ownProps) {
    return {
        sheets: state.sheets
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(sheetActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(SheetsPage);