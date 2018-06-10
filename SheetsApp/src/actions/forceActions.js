import * as types from './actionTypes';
import forcesApi from '../api/mockForceApi';

export function loadForcesSuccess(forces) {
    return { type: types.LOAD_FORCES_SUCCESS, forces };
}

export function loadForces() {
    return function(dispatch) {
        return forcesApi.getAllForces().then((forces) => {
            dispatch(loadForcesSuccess(forces));
        }).catch((error) => {
            throw(error);
        });
    };
}