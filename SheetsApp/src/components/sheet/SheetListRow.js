import React, { PropTypes } from 'react';
import { Link } from 'react-router';

const SheetListRow = ({sheet, forces}) => {
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
            <td>{forces.filter(force => force.id == sheet.forceId)[0].name}</td>
            <td>{sheet.points}</td>
        </tr>
    );
};

SheetListRow.propTypes = {
    sheet: PropTypes.object.isRequired,
    forces: PropTypes.array.isRequired
};

export default SheetListRow;