import delay from './delay';

const sheets = [
  {
    id: 1,
    name: "Standard dude",
    movement: 6,
    weaponSkill: 4,
    ballisticSkill: 3,
    strength: 3,
    toughness: 3,
    wounds: 1,
    attacks: 1,
    leadership: 6,
    save: 5,
    invulnerableSave: 0
  },
  {
    id: 2,
    name: "Other dude",
    movement: 6,
    weaponSkill: 3,
    ballisticSkill: 4,
    strength: 4,
    toughness: 3,
    wounds: 1,
    attacks: 2,
    leadership: 6,
    save: 5,
    invulnerableSave: 0
  },
  {
    id: 3,
    name: "Speedy punch dude",
    movement: 8,
    weaponSkill: 3,
    ballisticSkill: 3,
    strength: 5,
    toughness: 3,
    wounds: 2,
    attacks: 1,
    leadership: 9,
    save: 5,
    invulnerableSave: 5
  },
  {
    id: 4,
    name: "Big dude",
    movement: 12,
    weaponSkill: 2,
    ballisticSkill: 3,
    strength: 6,
    toughness: 7,
    wounds: 12,
    attacks: 5,
    leadership: 10,
    save: 2,
    invulnerableSave: 4
  },
  {
    id: 5,
    name: "Leader dude",
    movement: 6,
    weaponSkill: 2,
    ballisticSkill: 2,
    strength: 4,
    toughness: 4,
    wounds: 5,
    attacks: 3,
    leadership: 10,
    save: 3,
    invulnerableSave: 5
  }
];

function replaceAll(str, find, replace) {
  return str.replace(new RegExp(find, 'g'), replace);
}

//This would be performed on the server in a real app. Just stubbing in.
const generateId = (sheet) => {
  return replaceAll(sheet.name, ' ', '-');
};

class SheetApi {
  static getAllSheets() {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(Object.assign([], sheets));
      }, delay);
    });
  }

  static saveSheet(sheet) {
    sheet = Object.assign({}, sheet); // to avoid manipulating object passed in.
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        // Simulate server-side validation
        const minSheetNameLength = 1;
        if (sheet.name.length < minSheetNameLength) {
          reject(`Name must be at least ${minSheetNameLength} characters.`);
        }

        if (sheet.id) {
          const existingSheetIndex = sheets.findIndex(a => a.id == sheet.id);
          sheets.splice(existingSheetIndex, 1, sheet);
        } else {
          sheet.id = generateId(sheet);
          sheets.push(sheet);
        }

        resolve(sheet);
      }, delay);
    });
  }

  static deleteSheet(sheetId) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        const indexOfSheetToDelete = sheets.findIndex(sheet => {
          sheet.id == sheetId;
        });
        sheets.splice(indexOfSheetToDelete, 1);
        resolve();
      }, delay);
    });
  }
}

export default SheetApi;
