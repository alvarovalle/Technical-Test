import './ListingList.css';
import '../App.css';
import '../bootstrap.min.css';
import React, { useEffect, useState } from "react"
import Home from './Home'
import { useNavigate } from "react-router-dom";

export default function ListingList() {

  const [listing, setListing] = useState([])
  const navigate = useNavigate();

  useEffect(() => {
    const fetchAllListingData = async () => {
      const response = await fetch(`http://localhost:5042/listing`);
      const json = await response.json();
      setListing(json);
    };

    fetchAllListingData();
  }, []);

  const handleClick = (id) => {
    navigate(`/edit/${id}`);
  }

  return (
    <div>
      <Home />
      <h4>All Listings</h4>
      <div className="container">
         <div className="row">
            <div className="col-sm">
              Name
            </div>
            <div className="col-sm">
              Description
            </div>
            <div className="col-sm">
              Building_type
            </div>
          </div>   
        {listing.map(l => (
          <div className="row item-click" key={l.id} onClick={()=>{handleClick(l.id)}}> 
            <div className="col-sm">
              {l.name}
            </div>
            <div className="col-sm">
              {l.description}
            </div>
            <div className="col-sm">
              {l.building_type}
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
