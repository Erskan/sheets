import React from 'react';
import expect from 'expect';
import { mount, shallow } from 'enzyme';
import { ManageSheetPage } from './ManageSheetPage';


        

describe('Manage Sheet Page', () => {
    it('sets an error message when trying to save an empty name', () => {
        const props = {
            forces: [],
            actions: { saveSheet: () => { return Promise.resolve(); } },
            sheet: {
                name: "",
                movement: 0,
                weaponSkill: 0,
                ballisticSkill: 0,
                strength: 0,
                toughness: 0,
                wounds: 0,
                attacks: 0,
                leadership: 0,
                save: 0,
                invulnerableSave: 0,
                forceId: 0,
                points: 0
            }
        };
        const wrapper = mount(<ManageSheetPage {...props}/>);
        const saveButton = wrapper.find('#sheet-form-save-button');
        expect(saveButton.prop('type')).toBe('submit');
        saveButton.simulate('click');
        expect(wrapper.state().errors.name).toBe('Name cannot be empty.');
    });
});