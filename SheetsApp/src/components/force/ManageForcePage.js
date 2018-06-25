import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as forceActions from '../../actions/forceActions';
import ForceForm from './ForceForm';
import toastr from 'toastr';

class ManageForcePage extends React.Component {
    constructor(props, context) {
        super(props, context);

        this.state = {
            force: Object.assign({}, props.force),
            errors: {},
            saving: false
        };
        this.updateForceState = this.updateForceState.bind(this);
        this.saveForce = this.saveForce.bind(this);
        this.redirect = this.redirect.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        if(this.props.force.id != nextProps.force.id) {
            this.setState({force: Object.assign({}, nextProps.force)});
        }
    }

    updateForceState(event) {
        const field = event.target.name;
        let force = Object.assign({}, this.state.force);
        force[field] = event.target.value;
        return this.setState({force: force});
    }

    saveForce(event) {
        event.preventDefault();
        this.setState({saving: true});
        this.props.actions.saveForce(this.state.force)
        .then(() => this.redirect())
        .catch((error) => {
            toastr.error(error);
            this.setState({saving: false});
        });
    }

    redirect() {
        this.setState({saving: false});
        toastr.success('Saved force!');
        this.context.router.push('/forces');
    }

    render() {
        return (
            <div>
                <h1>Manage Force</h1>
                <ForceForm 
                    force={this.state.force}
                    errors={this.state.errors}
                    onChange={this.updateForceState}
                    onSave={this.saveForce}
                    saving={this.state.saving}
                     />
            </div>
        );
    }
}

ManageForcePage.propTypes = {
    force: PropTypes.object.isRequired,
    actions: PropTypes.object.isRequired
};

ManageForcePage.contextTypes = {
    router: PropTypes.object
};

function getForceById(forces, forceId) {
    const force = forces.filter(f => f.id == forceId);
    if(force) {
        return force[0];
    }
    return null;
}

function mapStateToProps(state, ownProps) {
    const forceId = ownProps.params.id;
    
    let force = {
        id: 0,
        name: '',
        points: 0
    };

    if(forceId && state.forces.length > 0) {
        force = getForceById(state.forces, forceId);
    }

    return {
        force: force
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(forceActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ManageForcePage);