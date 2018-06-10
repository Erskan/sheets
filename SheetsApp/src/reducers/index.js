import { combineReducers } from 'redux';
import sheets from './sheetReducer';
import forces from './forceReducer';

const rootReducer = combineReducers({
    sheets,
    forces
});

export default rootReducer;