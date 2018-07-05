import expect from 'expect';
import { forcesFormattedForSelect } from './selectors';

describe('Force Selector', () => {
    describe('forcesFormattedForSelect', () => {
        it('should return forces formatted for use in select input', () => {
            const forces = [
                {
                    id: 1,
                    name: 'Buzz Killington',
                    points: 500
                },
                {
                    id: 2,
                    name: 'Infanteriet Anfaller',
                    points: 1000
                }
            ];

            const expected = [
                {
                    value: 1,
                    text: 'Buzz Killington'
                },
                {
                    value: 2,
                    text: 'Infanteriet Anfaller'
                }
            ];
            expect(forcesFormattedForSelect(forces)).toEqual(expected);
        });
    });
});