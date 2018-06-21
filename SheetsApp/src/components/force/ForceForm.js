import React, { PropTypes } from 'react';
import TextInput from '../common/TextInput';

const ForceForm = ({force, onSave, onChange, saving, errors}) => {
    return (
        <form>
            <TextInput
                name="name"
                label="Name"
                value={force.name}
                onChange={onChange}
                errors={errors} />
            <input
                type="submit"
                disabled={saving}
                value={saving ? 'Saving...' : 'Save'}
                className="btn btn-primary"
                onClick={onSave} />
        </form>
    );
};

ForceForm.propTypes = {
    force: PropTypes.object.isRequired,
    onSave: PropTypes.func.isRequired,
    onChange: PropTypes.func.isRequired,
    saving: PropTypes.bool.isRequired,
    errors: PropTypes.object
};

export default ForceForm;