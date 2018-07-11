import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router';

const ForceListRow = ({force}) => {
    return (
        <tr>
            <td><Link to={'/force/' + force.id}>{force.name}</Link></td>
        </tr>
    );
};

ForceListRow.propTypes = {
    force: PropTypes.object.isRequired
};

export default ForceListRow;