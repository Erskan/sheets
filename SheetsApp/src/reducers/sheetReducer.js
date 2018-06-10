import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function sheetReducer(state = initialState.sheets, action) {
    switch(action.type) {
        case types.LOAD_SHEETS_SUCCESS:
            return action.sheets;
        case types.CREATE_SHEET_SUCCESS:
            return [
                ...state,
                Object.assign({}, action.savedSheet)
            ];
        case types.UPDATE_SHEET_SUCCESS:
            return [
                ...state.filter(sheet => sheet.id != action.savedSheet.id),
                Object.assign({}, action.savedSheet)
            ];
        default:
            return state;
    }
}