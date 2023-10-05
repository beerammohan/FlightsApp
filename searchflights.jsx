import React, { Component } from 'react';

class FlightSearch extends Component {
  state = {
    source: '',
    destination: '',
    date: '',
    results: [],
  };

  handleInputChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  handleSearch = () => {
    const { source, destination, date } = this.state;
    console.log('Source:', source);
    console.log('Destination:', destination);
    console.log('Date:', date);

    // Construct the URL for your Web API endpoint with query parameters.
    // const apiUrl = `http://localhost:5237/api/Flights?source=${source}&destination=${destination}&date=${date}`;
    const apiUrl = `api/Flights?source=${source}&destination=${destination}&date=${date}`;
    // Make a GET request to your Web API.
    fetch(apiUrl)
      .then((response) => response.json())
      .then((data) => {
        // Update the UI with the retrieved data.
        this.setState({ results: data });
      })
      // .catch((error) => {
      //   console.error('Error:', error);
      // });
  };

  render() {
    const { source, destination, date, results } = this.state;

    return (
      <div>
        <input
          type="text"
          name="source"
          value={source}
          placeholder="Source"
          onChange={this.handleInputChange}
        />
        <input
          type="text"
          name="destination"
          value={destination}
          placeholder="Destination"
          onChange={this.handleInputChange}
        />
        <input
          type="text"
          name="date"
          value={date}
          placeholder="Date (yyyy-mm-dd)"
          onChange={this.handleInputChange}
        /><br/><br/>
        <button onClick={this.handleSearch}>Search</button>

        {results.length > 0 && (
          <div>
            <h2>Search Results:</h2>
            <ul>
              {results.map((result) => (
                <li key={result.FlightsId}>
                  {result.source} to {result.destination}, Date: {result.date}
                </li>
              ))}
            </ul>
          </div>
        )}
      </div>
    );
  }
}

export default FlightSearch;
