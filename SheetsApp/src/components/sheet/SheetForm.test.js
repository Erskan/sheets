import expect from 'expect';
import React from 'react';
import {mount, shallow} from 'enzyme';
import SheetForm from './SheetForm';

function setup(saving = false, deleting = false) {
    let props = {
        sheet: {},
        saving: saving,
        deleting: deleting,
        errors: {},
        onSave: () => {},
        onChange: () => {}
    };

    return shallow(<SheetForm {...props}/>);
}

describe('SheetForm', () => {
    it('renders a form', () => {
        const wrapper = setup(false);
        expect(wrapper.find('form').length).toBe(1);
    });

    it('Save button labeled Save when not saving', () => {
        const wrapper = setup(false);
        expect(wrapper.find('#sheet-form-save-button').props().value).toBe('Save');
    });

    it('Save button labeled Saving... when saving', () => {
        const wrapper = setup(true);
        expect(wrapper.find('#sheet-form-save-button').props().value).toBe('Saving...');
    });

    it('Delete button labeled Delete when not deleting', () => {
        const wrapper = setup(false, false);
        expect(wrapper.find('#sheet-form-delete-button').props().value).toBe('Delete');
    });

    it('Delete button labeled Deleting... when deleting', () => {
        const wrapper = setup(false, true);
        expect(wrapper.find('#sheet-form-delete-button').props().value).toBe('Deleting...');
    });
});
