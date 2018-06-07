import * as types from '../actions/actionTypes';

export default function sheetReducer(state = [], action) {
    switch(action.type) {
        case types.LOAD_SHEETS_SUCCESS:
            return action.sheets;
        default:
            return state;
    }
}