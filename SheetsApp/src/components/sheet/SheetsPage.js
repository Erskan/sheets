import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as sheetActions from '../../actions/sheetActions';
import SheetList from './SheetList';
import { browserHistory } from 'react-router';

class SheetsPage extends React.Component{
    constructor(props, context) {
        super(props, context);

        this.redirectToAddSheetPage = this.redirectToAddSheetPage.bind(this);
    }

    redirectToAddSheetPage(){
        browserHistory.push('/sheet');
    }

    render() {
        const { sheets, forces } = this.props;

        return(
            <div>
                <h1>Sheets</h1>
                <input
                    type="submit"
                    value="Add Sheet"
                    className="btn btn-primary"
                    onClick={this.redirectToAddSheetPage} />
                <SheetList sheets={sheets} forces={forces} />
            </div>
        );
    }
}

SheetsPage.propTypes = {
    sheets: PropTypes.array.isRequired,
    forces: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
};

function mapStateToProps(state, ownProps) {
    return {
        sheets: state.sheets,
        forces: state.forces
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(sheetActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(SheetsPage);