import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import ListingAdd from './core/ListingAdd.js';
import ListingList from './core/ListingList.js';
import Home from './core/Home.js';
import ListingEdit from "./core/ListingEdit.js";

const MyRoutes = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={<Home />} path="/" />
                <Route element={<ListingAdd />} path="/add" />
                <Route element={<ListingEdit />} path="/edit/{id}" />
                <Route element={<ListingList />} path="/list" />
            </Routes>
        </BrowserRouter>
    )
}

export default MyRoutes;