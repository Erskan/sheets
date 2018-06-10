import delay from './delay';

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
  },
  {
    id: 3,
    name: 'LoW n Stuff',
    points: 1500
  }
];

function generateId() {
  return forces.length + 1;
}

class ForceApi {
  static getAllForces() {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(Object.assign([], forces));
      }, delay);
    });
  }

  static saveForce(force) {
	force = Object.assign({}, force); // to avoid manipulating object passed in.
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        // Simulate server-side validation
        const minForceNameLength = 3;
        if (force.name.length < minForceNameLength) {
          reject(`Name must be at least ${minForceNameLength} characters.`);
        }

        const minForcePoints = 100;
        if (force.points < minForcePoints) {
          reject(`Points must be at least ${minForcePoints}.`);
        }

        if (force.id) {
          const existingForceIndex = force.findIndex(a => a.id == force.id);
          force.splice(existingForceIndex, 1, force);
        } else {
          force.id = generateId(force);
          forces.push(force);
        }

        resolve(force);
      }, delay);
    });
  }

  static deleteForce(forceId) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        const indexOfForceToDelete = forces.findIndex(force => {
          force.id == forceId;
        });
        forces.splice(indexOfForceToDelete, 1);
        resolve();
      }, delay);
    });
  }
}

export default ForceApi;
