import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function forceReducer(state = initialState.forces, action) {
    switch(action.type) {
        case types.LOAD_FORCES_SUCCESS:
            return action.forces;
        case types.CREATE_FORCE_SUCCESS:
            return [
                ...state,
                Object.assign({}, action.force)
            ];
        case types.UPDATE_FORCE_SUCCESS:
            return [
                ...state.filter(force => force.id != action.force.id),
                Object.assign({}, action.force)
            ];
        default:
            return state;
    }
}
