export function forcesFormattedForSelect(forces){
    return forces.map((force) => {
        return {
            value: force.id,
            text: force.name
        };
    });
} 