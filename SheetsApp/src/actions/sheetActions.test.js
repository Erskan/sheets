import expect from 'expect';
import * as sheetActions from './sheetActions';
import * as types from './actionTypes';
import thunk from 'redux-thunk';
import configureMockStore from 'redux-mock-store';

const middleware = [thunk];
const mockStore = configureMockStore(middleware);

describe('Async Actions', () => {
    it('should create BEGIN_AJAX_CALL and LOAD_SHEETS_SUCCESS when loading sheets', (done) => {
        const expectedActions = [
            {type: types.BEGIN_AJAX_CALL},
            {type: types.LOAD_SHEETS_SUCCESS, body: {sheets: [{
                id: 1,
                name: "Standard dude",
                movement: 6,
                weaponSkill: 4,
                ballisticSkill: 3,
                strength: 3,
                toughness: 3,
                wounds: 1,
                attacks: 1,
                leadership: 6,
                save: 5,
                invulnerableSave: 0,
                forceId: 1,
                points: 75
            }]}}
        ];

        const store = mockStore({sheets: []}, expectedActions);
        store.dispatch(sheetActions.loadSheets()).then(() => {
            const actions = store.getActions();
            expect(actions[0].type).toEqual(types.BEGIN_AJAX_CALL);
            expect(actions[1].type).toEqual(types.LOAD_SHEETS_SUCCESS);
            done();
        });
    });
});