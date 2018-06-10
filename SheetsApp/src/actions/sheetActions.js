import * as types from './actionTypes';
import sheetsApi from '../api/mockSheetApi';

export function loadSheetsSuccess(sheets) {
    return { type: types.LOAD_SHEETS_SUCCESS, sheets };
}

export function updateSheetSuccess(savedSheet) {
    return { type: types.UPDATE_SHEET_SUCCESS, savedSheet };
}

export function createSheetSuccess(savedSheet) {
    return { type: types.CREATE_SHEET_SUCCESS, savedSheet };
}

export function loadSheets() {
    return function(dispatch) {
        return sheetsApi.getAllSheets().then((sheets) => {
            dispatch(loadSheetsSuccess(sheets));
        }).catch((error) => {
            throw(error);
        });
    };
}

export function saveSheet(sheet) {
    return function(dispatch) {
        return sheetsApi.saveSheet(sheet).then((savedSheet) => {
            sheet.id ? dispatch(updateSheetSuccess(savedSheet)) :
                dispatch(createSheetSuccess(savedSheet));
        }).catch((error) => {
            throw(error);
        });
    };
}