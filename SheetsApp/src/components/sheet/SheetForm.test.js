import expect from 'expect';
import React from 'react';
import {mount, shallow} from 'enzyme';
import SheetForm from './SheetForm';

function setup(saving = false) {
    let props = {
        sheet: {},
        saving: saving,
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
        expect(wrapper.find('input').props().value).toBe('Save');
    });

    it('Save button labeled Saving... when saving', () => {
        const wrapper = setup(true);
        expect(wrapper.find('input').props().value).toBe('Saving...');
    });
});
