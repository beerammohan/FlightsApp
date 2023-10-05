import React,{ useState, useEffect } from 'react'
import {useFormik} from 'formik'
import axios from 'axios';

import './styles.css';
import { Link } from 'react-router-dom';

const Search = () => {
    const [flights, setFlights] = useState([]);
    useEffect(() => {
        axios.get('http://localhost:5237/api/Flights?source=Jaipur&destination=Banglore&date=2022-04-29')
          .then(response => {
            setFlights(response.data);
          })
          .catch(error => {
            console.error(error);
          });
      }, []);
    const formik = useFormik(
        {
        initialValues : {
            source : "",
            destination : "",
            date : ""
        }
        ,validate : values =>{
            const errors ={};

            if(!values.source)
            {
                errors.source="Please enter the source"
            }
                
            
            if(!values.destination)
            {
                errors.destination="Please enter the destination"
            }

            if(!values.date)
            {
                errors.date="Please enter the date"
            }

            return errors;
        }, onSubmit : values =>{
            console.log(values)
        }
    
        }
    )

    
  return (
    <div>
    
    <center><h2>Search Flights</h2></center>
    <form className="my-form" onSubmit={formik.handleSubmit}> 
    <label>Source&nbsp;</label>
    <input type="text"  id="source" name="source" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.source} /> <br />
    {formik.touched.source && formik.errors.source ? <div>{formik.errors.source}</div> : null} <br />

    <label>Destination&nbsp;</label>
    <input type="text"  id="destination" name="destination" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.destination} /> <br />
    {formik.touched.destination && formik.errors.destination ? <div>{formik.errors.destination}</div> : null} <br />
    
    <label>Date&nbsp;</label>
    <input type="text"  id="date" name="date" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.date} /> <br />
    {formik.touched.date && formik.errors.date ? <div>{formik.errors.date}</div> : null} <br />

    {/* <button type="submit" src='http://localhost:5173/myprofile'>Login</button>  <br /> */}
    <a href="http://localhost:5173/myprofile"> <button> Search  </button> </a> 
    {/* <h6>New User? Then click here&nbsp;&nbsp;<a href='http://localhost:5173/signup' >Register</a></h6> */}
    </form>
    <ul>
      {flights.map(flight => (
        <li key={flight.FlightsId}>
            {flight.Source}</li>
      ))}
    </ul>
    </div>
  )
}
  
export default Search