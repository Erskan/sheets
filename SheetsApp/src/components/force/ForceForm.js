import React from 'react';
import PropTypes from 'prop-types';
import TextInput from '../common/TextInput';
import NumberInput from '../common/NumberInput';

const ForceForm = ({force, onSave, onChange, saving, errors}) => {
    return (
        <form>
            <TextInput
                name="name"
                label="Name"
                value={force.name}
                onChange={onChange}
                errors={errors} />
            <NumberInput
                name="points"
                label="Points"
                value={force.points}
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