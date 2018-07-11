import React from 'react';
import PropTypes from 'prop-types';
import ForceListRow from './ForceListRow';

const ForceList = ({forces}) => {
    return (
        <table className="table">
            <thead>
            <tr>
                <th>Name</th>
            </tr>
            </thead>
            <tbody>
            {forces.map((force) => 
                <ForceListRow key={force.id} force={force} />
            )}
            </tbody>
        </table>
    );
};

ForceList.propTypes = {
    forces: PropTypes.array.isRequired
};

export default ForceList;