import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function sheetReducer(state = initialState.sheets, action) {
    switch(action.type) {
        case types.LOAD_SHEETS_SUCCESS:
            return action.sheets;
        default:
            return state;
    }
}