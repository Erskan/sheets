import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as forceActions from '../../actions/forceActions';
import ForceList from './ForceList';
import { browserHistory } from 'react-router';

class ForcePage extends React.Component{
    constructor(props, context) {
        super(props, context);

        this.redirectToAddForcePage = this.redirectToAddForcePage.bind(this);
    }

    redirectToAddForcePage(){
        browserHistory.push('/force');
    }

    render() {
        const { sheets, forces } = this.props;

        return(
            <div>
                <h1>Forces</h1>
                <input
                    type="submit"
                    value="Add Force"
                    className="btn btn-primary"
                    onClick={this.redirectToAddForcePage} />
                <ForceList sheets={sheets} forces={forces} />
            </div>
        );
    }
}

ForcePage.propTypes = {
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
        actions: bindActionCreators(forceActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ForcePage);