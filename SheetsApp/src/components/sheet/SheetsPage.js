import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
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
        this.props.dispatch(sheetActions.createSheet(this.state.sheet));
    }

    render() {
        return(
            <div>
                <h1>Sheets</h1>
                <h2>Create a new sheet</h2>
                <input type="text" onChange={this.onNameChange} value={this.state.sheet.name} />
                <input type="submit" value="Save" onClick={this.onClickSave} />
            </div>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {
        sheets: state.sheets
    };
}

export default connect(mapStateToProps)(SheetsPage);