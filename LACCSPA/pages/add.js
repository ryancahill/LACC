import Layout from '../components/Layout';
import React from 'react';
import Router from 'next/router'
import axios from 'axios';

class AddCigar extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      name: '',
      type: '',
      description: '',
      qty: 0
    };
    this.onFieldChange = this.onFieldChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit(event) {
    event.preventDefault();
    axios.post(`http://localhost:55905/api/Cigars`, this.state)
      .then(res => {
        console.log(res);
        console.log(res.data);
        if (res.data == "Already exists!")
        {
          alert(res.data);
        }
        else{
          alert(res.data);
          Router.push('/');
        }
      })
  }
  onFieldChange(event) {
    this.setState({
      [event.target.name]: event.target.value
    });
  }

  render() {
    return (
      <Layout>
        <form onSubmit={this.handleSubmit}>
          <div className="AddCigarForm__input">
            <label htmlFor="name">Name</label>
            <input type="text" name="name" value={this.state.name} onChange={this.onFieldChange} />
          </div>
          <div className="AddCigarForm__input">
            <label htmlFor="type">Type</label>
            <input type="text" name="type" value={this.state.type} onChange={this.onFieldChange} />
          </div>
          <div className="AddCigarForm__input">
            <label htmlFor="desc">Description</label>
            <input type="text" name="description" value={this.state.description} onChange={this.onFieldChange} />
          </div>
          <div className="AddCigarForm__input">
            <label htmlFor="qty">Quantity</label>
            <input type="text" name="qty" value={this.state.qty} onChange={this.onFieldChange} />
          </div>
          <input type="submit" value="Add" />
        </form>
      </Layout>);
  }
}

export default AddCigar;