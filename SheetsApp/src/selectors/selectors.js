export function forcesFormattedForSelect(forces){
    forces.map((force) => {
        return {
            value: force.id,
            text: force.name
        };
    });
} 