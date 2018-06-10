import React, { PropTypes } from 'react';
import TextInput from '../common/TextInput';
import SelectInput from '../common/SelectInput';

const SheetForm = ({sheet, forces, onSave, onChange, loading, errors}) => {
    return (
        <form>
            <TextInput
                name="name"
                label="Name"
                value={sheet.name}
                onChange={onChange}
                errors={errors} />
            <SelectInput
                name="force"
                label="Force"
                options={forces} />
        </form>
    );
};

SheetForm.propTypes = {
    sheet: PropTypes.object.isRequired,
    forces: PropTypes.array.isRequired,
    onSave: PropTypes.func.isRequired,
    onChange: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    errors: PropTypes.object
};

export default SheetForm;