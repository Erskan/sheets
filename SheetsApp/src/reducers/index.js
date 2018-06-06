import { combineReducers } from 'redux';
import sheets from './sheetReducer';

const rootReducer = combineReducers({
    sheets
});

export default rootReducer;