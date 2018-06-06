import delay from './delay';

const sheets = [
  {
    id: 1,
    name: "Building Applications in React and Flux",
    watchHref: "http://www.pluralsight.com/courses/react-flux-building-applications",
    authorId: "cory-house",
    length: "5:08",
    category: "JavaScript"
  },
  {
    id: 2,
    name: "Clean Code: Writing Code for Humans",
    watchHref: "http://www.pluralsight.com/courses/writing-clean-code-humans",
    authorId: "cory-house",
    length: "3:10",
    category: "Software Practices"
  },
  {
    id: 3,
    name: "Architecting Applications for the Real World",
    watchHref: "http://www.pluralsight.com/courses/architecting-applications-dotnet",
    authorId: "cory-house",
    length: "2:52",
    category: "Software Architecture"
  },
  {
    id: 4,
    name: "Becoming an Outlier: Reprogramming the Developer Mind",
    watchHref: "http://www.pluralsight.com/courses/career-reboot-for-developer-mind",
    authorId: "cory-house",
    length: "2:30",
    category: "Career"
  },
  {
    id: 5,
    name: "Web Component Fundamentals",
    watchHref: "http://www.pluralsight.com/courses/web-components-shadow-dom",
    authorId: "cory-house",
    length: "5:10",
    category: "HTML5"
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
        if (sheet.title.length < minSheetNameLength) {
          reject(`Name must be at least ${minSheetNameLength} characters.`);
        }

        if (sheet.id) {
          const existingSheetIndex = sheets.findIndex(a => a.id == sheet.id);
          sheets.splice(existingSheetIndex, 1, sheet);
        } else {
          //Just simulating creation here.
          //The server would generate ids and watchHref's for new courses in a real app.
          //Cloning so copy returned is passed by value rather than by reference.
          sheet.id = generateId(sheet);
          sheet.watchHref = `http://www.pluralsight.com/courses/${sheet.id}`;
          sheet.push(sheet);
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
