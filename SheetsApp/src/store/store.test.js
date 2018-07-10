import expect from 'expect';
import { createStore } from 'redux';
import rootReducer from '../reducers';
import initialState from '../reducers/initialState';
import * as sheetActions from '../actions/sheetActions';

describe('Store', () => {
    it('should handle creating sheets', () => {
        const store = createStore(rootReducer, initialState);
        const sheet = {
            name: 'A Sheet'
        };

        const action = sheetActions.createSheetSuccess(sheet);
        store.dispatch(action);

        const actualSheet = store.getState().sheets[0];
        expect(actualSheet.name).toEqual(sheet.name);
    });
});