import * as types from '../actions/actionTypes';

export default function sheetReducer(state = [], action) {
    switch(action.type) {
        case types.CREATE_COURSE:
            return [...state,
                Object.assign({}, action.sheet)
            ];
        default:
            return state;
    }
}