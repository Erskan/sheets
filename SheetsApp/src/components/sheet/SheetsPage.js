import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as sheetActions from '../../actions/sheetActions';

class SheetsPage extends React.Component{
    constructor(props, context) {
        super(props, context);
        this.state = {
            sheet: { name: "" }
        };

        this.onNameChange = this.onNameChange.bind(this);
        this.onClickSave = this.onClickSave.bind(this);
    }
    
    onNameChange(event) {
        const sheet = this.state.sheet;
        sheet.name = event.target.value;
        this.setState({sheet: sheet});
    }

    onClickSave() {
        this.props.actions.createSheet(this.state.sheet);
    }

    sheetsRow(sheet, index) {
        return <div key={index}>{sheet.name}</div>;
    }

    render() {
        return(
            <div>
                <h1>Sheets</h1>
                {this.props.sheets.map(this.sheetsRow)}
                <h2>Create a new sheet</h2>
                <input type="text" onChange={this.onNameChange} value={this.state.sheet.name} />
                <input type="submit" value="Save" onClick={this.onClickSave} />
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