export default function sheetReducer(state = [], action) {
    switch(action.type) {
        case 'CREATE_SHEET':
            return [...state,
                Object.assign({}, action.sheet)
            ];
        default:
            return state;
    }
}