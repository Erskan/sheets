import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function forceReducer(state = initialState.forces, action) {
    switch(action.type) {
        case types.LOAD_FORCES_SUCCESS:
            return action.forces;
        default:
            return state;
    }
}
