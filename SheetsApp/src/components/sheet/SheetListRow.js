import React, { PropTypes } from 'react';
import { Link } from 'react-router';

const SheetListRow = ({sheet}) => {
    return (
        <tr>
            <td>&nbsp;</td>
            <td><Link to={'/sheet/' + sheet.id}>{sheet.name}</Link></td>
            <td>{sheet.movement}</td>
            <td>{sheet.weaponSkill}</td>
            <td>{sheet.ballisticSkill}</td>
            <td>{sheet.strength}</td>
            <td>{sheet.toughness}</td>
            <td>{sheet.wounds}</td>
            <td>{sheet.attacks}</td>
            <td>{sheet.leadership}</td>
            <td>{sheet.save}</td>
            <td>{sheet.invulnerableSave}</td>
        </tr>
    );
};

SheetListRow.propTypes = {
    sheet: PropTypes.object.isRequired
};

export default SheetListRow;