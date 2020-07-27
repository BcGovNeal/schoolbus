import React from 'react';
import PropTypes from 'prop-types';

import { connect } from 'react-redux';

import { Container, Row, Col } from 'react-bootstrap';
import { Form, FormGroup } from 'react-bootstrap';

import _ from 'lodash';

import * as Api from '../../api';

import DateControl from '../../components/DateControl.jsx';
import EditDialog from '../../components/EditDialog.jsx';
import DropdownControl from '../../components/DropdownControl.jsx';
import Spinner from '../../components/Spinner.jsx';

import { isValidDate, toZuluTime } from '../../utils/date';
import { isBlank, notBlank } from '../../utils/string';

class UserRoleAddDialog extends React.Component {
  static propTypes = {
    roles: PropTypes.object,
    onSave: PropTypes.func.isRequired,
    onClose: PropTypes.func.isRequired,
    show: PropTypes.bool,
  };

  state = {
    loading: false,

    roleId: 0,
    effectiveDate: '',
    expiryDate: '',

    roleIdError: '',
    effectiveDateError: '',
    expiryDateError: '',
  };

  componentDidMount() {
    this.setState({ loading: true });
    Api.getRoles().finally(() => {
      this.setState({ loading: false });
    });
  }

  updateState = (state, callback) => {
    this.setState(state, callback);
  };

  didChange = () => {
    if (this.state.roleId !== 0) {
      return true;
    }
    if (notBlank(this.state.effectiveDate)) {
      return true;
    }
    if (notBlank(this.state.expiryDate)) {
      return true;
    }

    return false;
  };

  isValid = () => {
    this.setState({
      roleIdError: false,
      effectiveDateError: false,
      expiryDateError: false,
    });

    var valid = true;
    if (!this.state.roleId) {
      this.setState({ roleIdError: 'Role is required' });
      valid = false;
    }

    if (isBlank(this.state.effectiveDate)) {
      this.setState({ effectiveDateError: 'Effective date is required' });
      valid = false;
    } else if (!isValidDate(this.state.effectiveDate)) {
      this.setState({ effectiveDateError: 'Effective date not valid' });
      valid = false;
    }

    if (notBlank(this.state.expiryDate) && !isValidDate(this.state.expiryDate)) {
      this.setState({ expiryDateError: 'Expiry date not valid' });
      valid = false;
    }

    return valid;
  };

  onSave = () => {
    this.props.onSave({
      roleId: this.state.roleId,
      effectiveDate: toZuluTime(this.state.effectiveDate),
      expiryDate: toZuluTime(this.state.expiryDate),
    });
  };

  render() {
    if (this.state.loading) {
      return (
        <div style={{ textAlign: 'center' }}>
          <Spinner />
        </div>
      );
    }

    var roles = _.sortBy(this.props.roles, 'name');

    return (
      <EditDialog
        id="add-role"
        show={this.props.show}
        title={<strong>Add Role</strong>}
        onClose={this.props.onClose}
        onSave={this.onSave}
        didChange={this.didChange}
        isValid={this.isValid}
      >
        <Form>
          <Container fluid>
            <Row>
              <Col md={4}>
                <FormGroup controlId="roleId" validationState={this.state.roleIdError ? 'error' : null}>
                  <Form.Label>
                    Role <sup>*</sup>
                  </Form.Label>
                  <DropdownControl
                    id="roleId"
                    placeholder="None"
                    blankLine
                    items={roles}
                    selectedId={this.state.roleId}
                    updateState={this.updateState}
                  />
                  <Form.Text>{this.state.roleIdError}</Form.Text>
                </FormGroup>
              </Col>
              <Col md={4}>
                <FormGroup controlId="effectiveDate" validationState={this.state.effectiveDateError ? 'error' : null}>
                  <Form.Label>
                    Effective Date <sup>*</sup>
                  </Form.Label>
                  <DateControl
                    id="effectiveDate"
                    date={this.state.effectiveDate}
                    updateState={this.updateState}
                    placeholder="mm/dd/yyyy"
                    title="effective date"
                  />
                  <Form.Text>{this.state.effectiveDateError}</Form.Text>
                </FormGroup>
              </Col>
              <Col md={4}>
                <FormGroup controlId="expiryDate" validationState={this.state.expiryDateError ? 'error' : null}>
                  <Form.Label>Expiry Date</Form.Label>
                  <DateControl
                    id="expiryDate"
                    date={this.state.expiryDate}
                    updateState={this.updateState}
                    placeholder="mm/dd/yyyy"
                    title="expiry date"
                  />
                  <Form.Text>{this.state.expiryDateError}</Form.Text>
                </FormGroup>
              </Col>
            </Row>
          </Container>
        </Form>
      </EditDialog>
    );
  }
}

function mapStateToProps(state) {
  return {
    roles: state.lookups.roles,
  };
}

export default connect(mapStateToProps)(UserRoleAddDialog);
