import React, { PropTypes } from 'react';
import TextInput from '../common/TextInput';

const SheetForm = ({sheet, onSave, onChange, loading, errors}) => {
    return (
        <form>
            <h1>Manage Form</h1>
            <TextInput
                name="name"
                label="name"
                value={sheet.name}
                onChange={onChange}
                errors={errors} />
        </form>
    );
};

SheetForm.propTypes = {
    sheet: PropTypes.object.isRequired,
    onSave: PropTypes.func.isRequired,
    onChange: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    errors: PropTypes.object
};

export default SheetForm;