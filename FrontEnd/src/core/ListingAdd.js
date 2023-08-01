import './ListingAdd.css';
import '../App.css';
import React, { useEffect, useState } from "react"
import Home from './Home'

export default function ListingAdd() {
  const [inputs, setInputs] = useState({});

  const handleChange = (event) => {
    const name = event.target.name;
    const value = event.target.value;
    setInputs(values => ({ ...values, [name]: value }))
  }

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      let res = await fetch(`http://localhost:5042/listing`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Accept": "application/json"
        },
        body: JSON.stringify({
          Created_date: inputs["Created_date"],
          Updated_date: inputs["Updated_date"],
          Name: inputs["Name"],
          Description: inputs["Description"],
          Building_type: inputs["Building_type"],
          Latest_price_eur: inputs["Latest_price_eur"],
          Surface_area_m2: inputs["Surface_area_m2"],
          Rooms_count: inputs["Rooms_count"],
          Bedrooms_count: inputs["Bedrooms_count"],
          Contact_phone_number: inputs["Contact_phone_number"],
          PostalAddress: {
            City: inputs["City"],
            Country: inputs["Country"],
            Postal_code: inputs["Postal_code"],
            Street_address: inputs["Street_address"]
          }
        })
      });
      let resJson = await res.json();
      if (res.status === 200) {
        alert("User created successfully");
      } else {
        alert("Some error occured");
      }

    } catch (err) {
      console.log(err);
    }
  };
  return (
    <div>      
      <Home />
      <h4>Add Listing</h4>
      <div className="container">
      <form onSubmit={handleSubmit}>
        <div className='input-box'>
          <label>Created_date</label>
          <input type="text" name="Created_date" value={inputs.Created_date || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Updated_date</label>
          <input type="text" name="Updated_date" value={inputs.Updated_date || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Name</label>
          <input type="text" name="Name" value={inputs.Name || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Description</label>
          <input type="text" name="Description" value={inputs.Description || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Building_type</label>
          <input type="text" name="Building_type" value={inputs.Building_type || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Latest_price_eur</label>
          <input type="text" name="Latest_price_eur" value={inputs.Latest_price_eur || 0} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Surface_area_m2</label>
          <input type="text" name="Surface_area_m2" value={inputs.Surface_area_m2 || 0} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Rooms_count</label>
          <input type="text" name="Rooms_count" value={inputs.Rooms_count || 0} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Bedrooms_count</label>
          <input type="text" name="Bedrooms_count" value={inputs.Bedrooms_count || 0} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Contact_phone_number</label>
          <input type="text" name="Contact_phone_number" value={inputs.Contact_phone_number || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>City</label>
          <input type="text" name="City" value={inputs.City || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Country</label>
          <input type="text" name="Country" value={inputs.Country || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Postal_code</label>
          <input type="text" name="Postal_code" value={inputs.Postal_code || ""} onChange={handleChange} />
        </div>
        <div className='input-box'>
          <label>Street_address</label>
          <input type="text" name="Street_address" value={inputs.Street_address || ""} onChange={handleChange} />
        </div>
        <input type="submit" value="Send" />
      </form>

      </div>
    </div>
  )
}
