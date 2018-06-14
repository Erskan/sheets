import { combineReducers } from 'redux';
import sheets from './sheetReducer';
import forces from './forceReducer';
import ajaxCallsInProgress from './ajaxStatusReducer';

const rootReducer = combineReducers({
    sheets,
    forces,
    ajaxCallsInProgress
});

export default rootReducer;