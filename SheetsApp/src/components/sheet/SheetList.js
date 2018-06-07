import React, { PropTypes } from 'react';
import SheetListRow from './SheetListRow';

const SheetList = ({sheets}) => {
    return (
        <table className="table">
            <thead>
            <tr>
                <th>&nbsp;</th>
                <th>Name</th>
                <th>Movement</th>
                <th>Weapon Skill</th>
                <th>Ballistic Skill</th>
                <th>Strength</th>
                <th>Toughness</th>
                <th>Wounds</th>
                <th>Attacks</th>
                <th>Leadership</th>
                <th>Save</th>
                <th>Invulnerable Save</th>
            </tr>
            </thead>
            <tbody>
            {sheets.map((sheet) => 
                <SheetListRow key={sheet.id} sheet={sheet} />
            )}
            </tbody>
        </table>
    );
};

SheetList.propTypes = {
    sheets: PropTypes.array.isRequired
};

export default SheetList;