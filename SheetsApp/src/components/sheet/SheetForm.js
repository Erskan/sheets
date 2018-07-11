import React from 'react';
import PropTypes from 'prop-types';
import TextInput from '../common/TextInput';
import SelectInput from '../common/SelectInput';
import NumberInput from '../common/NumberInput';

const SheetForm = ({sheet, forces, onSave, onDelete, onChange, saving, deleting, errors}) => {
    return (
        <form>
            <TextInput
                name="name"
                label="Name"
                value={sheet.name}
                onChange={onChange}
                error={errors.name} />
            <SelectInput
                name="forceId"
                label="Force"
                value={sheet.forceId}
                defaultOption="Select Force"
                options={forces}
                onChange={onChange}
                error={errors.forceId} />
            <NumberInput
                name="movement"
                label="Movement"
                value={sheet.movement}
                onChange={onChange}
                error={errors.movement} />
            <NumberInput
                name="weaponSkill"
                label="Weapon Skill"
                value={sheet.weaponSkill}
                onChange={onChange}
                error={errors.weaponSkill} />
            <NumberInput
                name="ballisticSkill"
                label="Ballistic Skill"
                value={sheet.ballisticSkill}
                onChange={onChange}
                error={errors.ballisticSkill} />
            <NumberInput
                name="strength"
                label="Strength"
                value={sheet.strength}
                onChange={onChange}
                error={errors.strength} />
            <NumberInput
                name="toughness"
                label="Toughness"
                value={sheet.toughness}
                onChange={onChange}
                error={errors.toughness} />
            <NumberInput
                name="wounds"
                label="Wounds"
                value={sheet.wounds}
                onChange={onChange}
                error={errors.wounds} />
            <NumberInput
                name="attacks"
                label="Attacks"
                value={sheet.attacks}
                onChange={onChange}
                error={errors.attacks} />
            <NumberInput
                name="leadership"
                label="Leadership"
                value={sheet.leadership}
                onChange={onChange}
                error={errors.leadership} />
            <NumberInput
                name="save"
                label="Save"
                value={sheet.save}
                onChange={onChange}
                error={errors.save} />
            <NumberInput
                name="invulnerableSave"
                label="Invulnerable Save"
                value={sheet.invulnerableSave}
                onChange={onChange}
                error={errors.invulnerableSave} />
            <NumberInput
                name="points"
                label="Base Points Cost"
                value={sheet.points}
                onChange={onChange}
                error={errors.points} />
            <input
                type="submit"
                id="sheet-form-save-button"
                disabled={saving | deleting}
                value={saving ? 'Saving...' : 'Save'}
                className="btn btn-primary"
                onClick={onSave} />
            <input
                type="submit"
                id="sheet-form-delete-button"
                disabled={saving | deleting}
                value={deleting ? 'Deleting...' : 'Delete'}
                className="btn btn-danger"
                onClick={onDelete} />
        </form>
    );
};

SheetForm.propTypes = {
    sheet: PropTypes.object.isRequired,
    forces: PropTypes.array.isRequired,
    onSave: PropTypes.func.isRequired,
    onDelete: PropTypes.func.isRequired,
    onChange: PropTypes.func.isRequired,
    saving: PropTypes.bool.isRequired,
    deleting: PropTypes.bool.isRequired,
    errors: PropTypes.object
};

export default SheetForm;