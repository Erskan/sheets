import * as types from './actionTypes';

export function createSheet(sheet) {
    return { type: types.CREATE_COURSE, sheet };
}
