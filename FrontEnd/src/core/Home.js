import './Home.css';
import React, { useEffect, useState } from "react"
import { Outlet, Link } from "react-router-dom";

export default function Home() {
  
    return (
        <>
          <nav>
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/list">Listing</Link>
              </li>
              <li>
                <Link to="/add">Add</Link>
              </li>
            </ul>
          </nav>
    
          <Outlet />
        </>)
}
