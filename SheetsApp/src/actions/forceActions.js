import * as types from './actionTypes';
import forcesApi from '../api/mockForceApi';
import { beginAjaxCall, ajaxCallError } from './ajaxStatusActions';

export function loadForcesSuccess(forces) {
    return { type: types.LOAD_FORCES_SUCCESS, forces };
}

export function createForceSuccess(force) {
    return { type: types.CREATE_FORCE_SUCCESS, force };
}

export function updateForceSuccess(force) {
    return { type: types.UPDATE_FORCE_SUCCESS, force };
}

export function loadForces() {
    return function(dispatch) {
        dispatch(beginAjaxCall());
        return forcesApi.getAllForces().then((forces) => {
            dispatch(loadForcesSuccess(forces));
        }).catch((error) => {
            dispatch(ajaxCallError(error));
            throw(error);
        });
    };
}

export function saveForce(force) {
    return function(dispatch) {
        dispatch(beginAjaxCall);
        return forcesApi.saveForce(force).then((force) => {
            force.id ? 
                dispatch(updateForceSuccess(force)) :
                dispatch(createForceSuccess(force));
        }).catch((error) => {
            dispatch(ajaxCallError(error));
            throw(error);
        });
    };
}