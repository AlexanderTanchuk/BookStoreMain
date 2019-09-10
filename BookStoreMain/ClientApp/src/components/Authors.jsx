import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Authors';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import DropDownBooks from './DropdownField';//'components/product/product-card'

class Authors extends Component {
  constructor(props) {
    super(props);
    console.log("Authors constructor called");
    
  }

  componentWillMount() {
    // This method runs when the component is first added to the page
    console.log("Authors WillMount called");
    this.props.requestAuthors();
  }

  componentWillReceiveProps(nextProps) {
    // This method runs when incoming props (e.g., route params) change
    //this.props.requestAuthors();
    console.log("Authors WillReceiveProps called");
  }
  
  

  render() {
    console.log("Authors Render called");
      return (
          <div>
              <h1>Authors</h1>
              <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
              {this.renderAuthorsTable()}
          </div>
      );
  }

  renderAuthorsTable() {
      return (
        <table className='table'>
          <thead>
            <tr>
              <th>Name</th>
              <th>Books</th>
            </tr>
          </thead>
          <tbody>
            {this.props.authors.map(author =>
              <tr key={author.id}>
                <td>{author.name}</td>
                <DropDownBooks title="Books" lines={author.books} />
              </tr>
            )}
          </tbody>
        </table>
          );
  }
}

function mapStateToProps(state) {
  console.log("Authors MSTP called");
  return state.authors_list;
}

export default connect(
  //state => state.authors_list,
  mapStateToProps,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Authors);