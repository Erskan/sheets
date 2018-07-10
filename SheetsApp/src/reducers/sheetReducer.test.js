import expect from 'expect';
import sheetReducer from './sheetReducer';
import * as actions from './../actions/sheetActions';

describe('Sheet Reducer', () => {
    it('should add a sheet when passed CREATE_SHEET_SUCCESS', () => {
        const initialState = [
            {name: 'A'},
            {name: 'B'}
        ];
        const newSheet = {name: 'C'};
        const action = actions.createSheetSuccess(newSheet);
        
        const newState = sheetReducer(initialState, action);

        expect(newState.length).toEqual(3);
        expect(newState[0].name).toEqual('A');
        expect(newState[1].name).toEqual('B');
        expect(newState[2].name).toEqual('C');
    });

    it('should update a sheet when passed UPDATE_SHEET_SUCCESS', () => {
        const initialState = [
            {id: 1, name: 'A'},
            {id: 2, name: 'B'},
            {id: 3, name: 'C'}
        ];
        const updatedSheet = {id: 2, name: 'F'};
        const action = actions.updateSheetSuccess(updatedSheet);
        
        const newState = sheetReducer(initialState, action);
        const newSheet = newState.find(s => s.id == updatedSheet.id);
        const untouchedSheet = newState.find(s => s.id == 3);

        expect(newState.length).toEqual(3);
        expect(newSheet.name).toEqual('F');
        expect(untouchedSheet.name).toEqual('C');
    });
});