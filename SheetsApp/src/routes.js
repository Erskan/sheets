import React from 'react';
import {Route, IndexRoute} from 'react-router';
import App from './components/App';
import HomePage from './components/home/HomePage';
import AboutPage from './components/about/AboutPage';
import SheetsPage from './components/sheet/SheetsPage';
import ManageSheetPage from './components/sheet/ManageSheetPage'; //eslint-disable-line import/no-named-as-default
import ForcePage from './components/force/ForcePage';
import ManageForcePage from './components/force/ManageForcePage';

export default (
    <Route path="/" component={App}>
        <IndexRoute component={HomePage} />
        <Route path="about" component={AboutPage} />
        <Route path="sheets" component={SheetsPage} />
        <Route path="sheet" component={ManageSheetPage} />
        <Route path="sheet/:id" component={ManageSheetPage} />
        <Route path="forces" component={ForcePage} />
        <Route path="force" component={ManageForcePage} />
        <Route path="force/:id" component={ManageForcePage} />
    </Route>
);
