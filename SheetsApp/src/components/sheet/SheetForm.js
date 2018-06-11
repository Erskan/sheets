import React, { PropTypes } from 'react';
import TextInput from '../common/TextInput';
import SelectInput from '../common/SelectInput';
import NumberInput from '../common/NumberInput';

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
                defaultOption="Select Force"
                options={forces}
                onChange={onChange} />
            <NumberInput
                name="movement"
                label="Movement"
                value={sheet.movement}
                onChange={onChange} />
            <NumberInput
                name="weaponSkill"
                label="Weapon Skill"
                value={sheet.weaponSkill}
                onChange={onChange} />
            <NumberInput
                name="ballisticSkill"
                label="Ballistic Skill"
                value={sheet.ballisticSkill}
                onChange={onChange} />
            <NumberInput
                name="strength"
                label="Strength"
                value={sheet.strength}
                onChange={onChange} />
            <NumberInput
                name="toughness"
                label="Toughness"
                value={sheet.toughness}
                onChange={onChange} />
            <NumberInput
                name="wounds"
                label="Wounds"
                value={sheet.wounds}
                onChange={onChange} />
            <NumberInput
                name="attacks"
                label="Attacks"
                value={sheet.attacks}
                onChange={onChange} />
            <NumberInput
                name="leadership"
                label="Leadership"
                value={sheet.leadership}
                onChange={onChange} />
            <NumberInput
                name="save"
                label="Save"
                value={sheet.save}
                onChange={onChange} />
            <NumberInput
                name="invulnerableSave"
                label="Invulnerable Save"
                value={sheet.invulnerableSave}
                onChange={onChange} />
            <input
                type="submit"
                disabled={loading}
                value={loading ? 'Saving...' : 'Save'}
                className="btn btn-primary"
                onClick={onSave} />
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