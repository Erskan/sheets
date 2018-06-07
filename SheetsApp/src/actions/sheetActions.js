import * as types from './actionTypes';
import sheetsApi from '../api/mockSheetApi';

export function loadSheetsSuccess(sheets) {
    return { type: types.LOAD_SHEETS_SUCCESS, sheets };
}

export function loadSheets() {
    return function(dispatch) {
        return sheetsApi.getAllSheets().then((sheets) => {
            dispatch(loadSheetsSuccess(sheets));
        }).catch((error) => {
            throw(error);
        });
    }
}